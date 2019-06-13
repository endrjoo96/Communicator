﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace Communicator
{
    class TalkingTask
    {
        private Thread task_send;
        private Thread task_play;
        private IPAddress IP;
        public byte[] sample = new byte[Toolbox.BUFFERSIZE];
        private bool _stop = false;

        public TalkingTask(IPAddress ip)
        {
            IP = ip;
            task_send = new Thread(() =>
            {
                byte[] sendsample = new byte[Toolbox.BUFFERSIZE];
                bool recording = false;
                bool stop = false;

                
                WaveInEvent wi = new WaveInEvent();
                wi.DeviceNumber = 0;
                wi.WaveFormat = new WaveFormat(Toolbox.RATE, 2);
                wi.BufferMilliseconds = (int)((double)(Toolbox.BUFFERSIZE/2) / (double)Toolbox.RATE * 1000.0);
                wi.DataAvailable += new EventHandler<WaveInEventArgs>(AudioDataAvailable);

                while (true)
                {
                    
                    if (stop)
                    {
                        if (recording)
                        {
                            wi.StopRecording();
                            recording = false;
                            wi.DataAvailable -= AudioDataAvailable;
                        }
                    }
                    else
                    {
                        if (!recording)
                        {
                            try
                            {
                                wi.StartRecording();
                                recording = true;
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            });
            task_send.IsBackground = true;


            task_play = new Thread(() =>
            {
                UdpClient client = new UdpClient(45002);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                WaveOutEvent wo = new WaveOutEvent();

                while (true)
                {
                    Byte[] rec = client.Receive(ref remoteEndPoint);
                    string recstr = Encoding.ASCII.GetString(rec);
                    string header = recstr.Substring(0, Definitions.DISCONNECTING.Length);
                    if (header.Equals(Definitions.DISCONNECTING))
                    {
                        
                    }
                    else
                    {
                        wo.Init(new RawSourceWaveStream(rec, 0, rec.Length, new WaveFormat(Toolbox.RATE, 1)));
                        wo.Play();
                    }
                }


            });
            task_play.IsBackground = true;
        }

        private void AudioDataAvailable(object sender, WaveInEventArgs e)
        {
            UdpClient client = new UdpClient();
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, 45002);
            client.Send(e.Buffer, e.BytesRecorded, remoteEndPoint);
        }

        public void Run()
        {
            task_send.Start();
            task_play.Start();
        }

        public void Stop()
        {
            _stop = true;
        }
    }
}

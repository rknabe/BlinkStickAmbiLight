#region License
/*
*
* The MIT License (MIT)
*
* Copyright (c) 2017 René Kannegießer
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

//using SlimDX;
//using SlimDX.Direct3D9;

namespace BlinkStickAmbiLight
{
    public partial class MainForm : Form
    {
        //private static readonly object lockobj = new object();
        //private Device device = null;
        //private Surface surface = null;

        private void DXInit()
        {
            /* try
             {
                 var present_params = new PresentParameters();
                 present_params.Windowed = true;
                 present_params.SwapEffect = SwapEffect.Discard;
                 present_params.BackBufferCount = 1;

                 present_params.PresentationInterval = PresentInterval.Immediate;

                 present_params.BackBufferHeight = Screen.AllScreens[iScreen].WorkingArea.Height;
                 present_params.BackBufferWidth = Screen.AllScreens[iScreen].WorkingArea.Width;

                 device = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, present_params);
             }
             catch (Exception ex)
             {
                 log.Debug("[Init DirectX] - " + ex.Message);
             }*/
        }

        private void DXDispose()
        {
            /*  if (surface != null)
              {
                  surface.Dispose();
                  surface = null;
              }
              if (device != null)
              {
                  device.Dispose();
                  device = null;
              }*/
        }

        public Bitmap GetImage(Rectangle rect)
        {
            Bitmap screenshot = null;
            if (rect == null)
            {
                log.Debug("rect is null");
                return null;
            }
            try
            {
                screenshot = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppRgb);
                using (Graphics gfxSreenshot = Graphics.FromImage(screenshot))
                {
                    gfxSreenshot.CompositingQuality = CompositingQuality.HighSpeed;
                    gfxSreenshot.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
                }
                return screenshot;
            }
            catch (Exception ex)
            {
                if (screenshot != null)
                {
                    screenshot.Dispose();
                }
                log.Debug("GetImage - " + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Get DX screen image
        /// </summary>
        /// <param name="rect">Screen rectangle</param>        
        /*
        public Bitmap
            GetImage1(Rectangle rect)
        {
            Bitmap bm = null;
            try
            {
                lock (lockobj)
                {
                    if (device == null)
                    {

                        DXDispose();
                        DXInit();
                    }
                    if (surface == null)
                    {
                        surface = Surface.CreateOffscreenPlain(device, rect.Width, rect.Height, Format.A8R8G8B8, Pool.Scratch);
                    }

                    device.GetFrontBufferData(0, surface);
                    DataRectangle gsx = surface.LockRectangle(rect, LockFlags.None);
                    bm = new Bitmap(rect.Width, rect.Height, CalculateStride(rect.Width, PixelFormat.Format32bppPArgb), PixelFormat.Format32bppPArgb, gsx.Data.DataPointer);
                    //Bitmap thumbnail = (Bitmap)bm.GetThumbnailImage(pbPreview.Width = (Screen.AllScreens[iScreen].Bounds.Width) / preview_factor, pbPreview.Height = Screen.AllScreens[iScreen].Bounds.Height / preview_factor, null, IntPtr.Zero);
                    //bm.Dispose();
                    surface.UnlockRectangle();
                    return bm;
                }
            }
            catch (Exception ex)
            {
                log.Debug("[DirectX GetScreenImage] - " + ex.Message);
                if (bm != null)
                {
                    bm.Dispose();
                }
                DXDispose();
                return null;
            }
        }

        private int CalculateStride(int width, PixelFormat pf)
        {
            int BitsPerPixel = ((int)pf & 0xff00) >> 8;
            return 4 * ((width * BitsPerPixel + 31) / 32);
        }*/
    }
}

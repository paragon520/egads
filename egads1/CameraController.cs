using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIS.Imaging;

namespace egads1
{
    class CameraController
    {
        private ICImagingControl camera;
        private string configFile;
        private int originalHeight;
        private int originalWidth;
        
        
        public CameraController(ICImagingControl ic, string _configFile)
        {
            camera = ic;
            configFile = _configFile;

            camera.OverlayBitmap.Enable = true;
            camera.OverlayBitmap.ColorMode = TIS.Imaging.OverlayColorModes.Color;
            try
            {
                camera.LoadDeviceStateFromFile(configFile, true); //attempts to load camera config file
                camera.DeviceTrigger = true;
                start(); // starts the live feed to the user interface
            }
            catch { } // do nothing if the above code produces errors
            camera.LiveDisplayDefault = false;
            originalHeight = camera.LiveDisplayHeight;
            originalWidth = camera.LiveDisplayWidth;
            camera.LiveDisplayHeight = camera.Height; // scales the camera view to the size of the window
            camera.LiveDisplayWidth = camera.Width;
            camera.LiveCaptureLastImage = false;
            camera.LiveCaptureContinuous = true;

        }

        public bool isCamLive
        {
            get
            {
                return camera.LiveVideoRunning;
            }
        }


        /// <summary>
        /// this is called when the device is disconnected
        /// </summary>
        public void DeviceLost()
        {
            camera.Device = "";
            System.Windows.Forms.MessageBox.Show("Device Lost!");
            //btCamProperties.Enabled = false;
        }

        /// <summary>
        /// this opens the capture device settings dialog
        /// </summary>
        public void OpenVideoCaptureDevice()
        {
            if (camera.DeviceValid)
            {
                camera.LiveStop();
            }
            camera.ShowDeviceSettingsDialog();
            if (camera.DeviceValid)
            {
                camera.SaveDeviceStateToFile(configFile);
            }
        }

        /// <summary>
        /// opens the device properties dialog
        /// </summary>
        public void ShowDeviceProperties()
        {
            if (camera.DeviceValid)
            {
                camera.ShowPropertyDialog();
                if (camera.DeviceValid)
                {
                    camera.SaveDeviceStateToFile(configFile);
                }

            }
        }

        /// <summary>
        /// enables the live video feed
        /// </summary>
        public void start()
        {
            camera.LiveStart();
        }

        /// <summary>
        /// disables the live video feed
        /// </summary>
        public void stop()
        {
            camera.LiveStop();
        }

        /// <summary>
        /// restarts the live feed
        /// </summary>
        public void restart()
        {
            if (isCamLive)
                stop();
            try
            {
                start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Make sure the correct camera is selected under Camera Devices. \n\n" + ex.Message);
            }
        }
        
        public void toggleTriggerMode()
        {
            if (camera.LiveCaptureContinuous)
            {
                camera.LiveStop();

                camera.LiveCaptureContinuous = false;
                camera.DeviceTrigger = false;

                camera.LiveStart();
            }
            else
            {
                camera.LiveStop();

                camera.LiveCaptureContinuous = true;
                camera.DeviceTrigger = true;

                camera.LiveStart();
            }
        }

        /// <summary>
        /// Captures the current image in the camera buffer and attempts to save it with the preferred filename. 
        /// If the file is in use, it will save with an appended number.
        /// </summary>
        /// <param name="filename">the preferred file name WITHOUT an extension (ie: "imageName")</param>
        /// <returns>actual filename saved (ie: "imageName.bmp" or "imageName2.bmp")</returns>
        public string manualCapture(string filename)
        {
            camera.MemorySnapImage();
            try
            {
                camera.ImageActiveBuffer.SaveAsBitmap(filename+".bmp");
                return filename + ".bmp";
            }
            catch (Exception ex)
            {
                camera.ImageActiveBuffer.SaveAsBitmap(filename + "2.bmp");
                return filename + "2.bmp";
            }
        }
        

    }
}

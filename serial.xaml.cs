using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Threading.Tasks;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace serialbad
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int counter = 0;
        public MainPage()
        {
            this.InitializeComponent();
            
            
        }
        public async void initPorts1() {
            
        }

        public async Task initPorts() {
            
            string selector = SerialDevice.GetDeviceSelector();
           
            DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);
            DeviceInformation deviceInfo = devices[0];
            Debug.WriteLine("Devices.Count: "+devices.Count);
            counter = 0;
            //serialDevice.Dispose();
            foreach (var info in devices)
            {
                
                SerialDevice serialDevice = await SerialDevice.FromIdAsync(info.Id);
                
                if (serialDevice != null)
                {

                    var port = serialDevice.PortName.ToString();
                    comPortList.Items.Add(port.ToString());
                    Debug.WriteLine(port.ToString());
                    
                }
                counter++;
                if (devices.Count == counter+1)
                {                    
                    Debug.WriteLine("Counter: "+counter);
                    serialDevice.Dispose();
                }

                

                


            }

           




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            comPortList.Items.Clear();
            initPorts();
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }


    
    


    }

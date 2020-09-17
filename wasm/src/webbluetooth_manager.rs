use buttplug::{
  core::ButtplugResultFuture,
  device::configuration_manager::DeviceConfigurationManager,
  server::comm_managers::{
  DeviceCommunicationEvent,
  DeviceCommunicationManager,
  DeviceCommunicationManagerCreator,
}
};
use wasm_bindgen_futures::{JsFuture, spawn_local};
use async_channel::Sender;
use futures::future;
use js_sys::{Promise, Array};

pub struct WebBluetoothCommunicationManager {
  sender: Sender<DeviceCommunicationEvent>,
}

impl DeviceCommunicationManagerCreator for WebBluetoothCommunicationManager {
  fn new(sender: Sender<DeviceCommunicationEvent>) -> Self {
    Self {
      sender,
    }
  }
}

impl DeviceCommunicationManager for WebBluetoothCommunicationManager {
  fn name(&self) -> &'static str {
    "WebBluetoothCommunicationManager"
  }

  fn start_scanning(&self) -> ButtplugResultFuture {
    info!("WebBluetooth manager scanning");
    spawn_local(async move {
      let config_manager = DeviceConfigurationManager::default();
      let mut options = web_sys::RequestDeviceOptions::new();
      let mut filters = Array::new();
      for (protocol_name, configs) in config_manager.config.protocols {
        if let Some(btle) = configs.btle {
          for name in btle.names {
            info!("{}", name);
            let mut filter = web_sys::BluetoothLeScanFilterInit::new();
            if name.contains("*") {
              let mut name_clone = name.clone();
              name_clone.pop();
              filter.name_prefix(&name_clone);
            } else {
              filter.name(&name);
            }
            filters.push(&filter.into());
          }
        }
      }
      options.filters(&filters.into());
      // Build the filter block
      let nav = web_sys::window().unwrap().navigator();
      //nav.bluetooth().get_availability();
      //JsFuture::from(nav.bluetooth().request_device()).await;      
      nav.bluetooth().request_device_with_options(&options);
    });
    Box::pin(future::ready(Ok(())))
  }

  fn stop_scanning(&self) -> ButtplugResultFuture {
    Box::pin(future::ready(Ok(())))
  }
}

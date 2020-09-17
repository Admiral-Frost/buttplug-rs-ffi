#[macro_use]
extern crate tracing;

mod utils;
mod websocket_client_connector;
mod webbluetooth_manager;

use buttplug::{
    client::{ButtplugClient, ButtplugClientEvent},
    core::messages::serializer::ButtplugClientJSONSerializer,
    connector::{ButtplugInProcessClientConnector, ButtplugRemoteClientConnector},
    test::TestDevice,
    util::async_manager,
};
use wasm_bindgen_futures::future_to_promise;
use futures::StreamExt;
use async_channel::Receiver;
use wasm_bindgen::prelude::*;
use std::sync::Arc;
use js_sys::Promise;
use web_sys;


// When the `wee_alloc` feature is enabled, use `wee_alloc` as the global
// allocator.
#[cfg(feature = "wee_alloc")]
#[global_allocator]
static ALLOC: wee_alloc::WeeAlloc = wee_alloc::WeeAlloc::INIT;

#[wasm_bindgen(start)]
pub fn start() -> Result<(), JsValue> {
    // print pretty errors in wasm https://github.com/rustwasm/console_error_panic_hook
    // This is not needed for tracing_wasm to work, but it is a common tool for getting proper error line numbers for panics.
    console_error_panic_hook::set_once();

    // Add this line:
    tracing_wasm::set_as_global_default();

    Ok(())
}

#[wasm_bindgen]
pub struct ButtplugClientWASM {
  client: Arc<ButtplugClient>
}

#[wasm_bindgen]
impl ButtplugClientWASM {

  pub fn connect_embedded() -> Promise {
    info!("Trying to connect!");
    future_to_promise(async move {
      info!("Now in future!");
      let mut connector = ButtplugInProcessClientConnector::new("Example Server", 0);
      connector.server_ref().add_comm_manager::<webbluetooth_manager::WebBluetoothCommunicationManager>();
      let (client, mut event_stream) = ButtplugClient::connect("Example Client", connector)
        .await
        .unwrap();
        info!("Connected in future!");
      Ok(Self {
        client: Arc::new(client)
      }.into())
    })
  }

  pub fn connect_websocket() -> Promise {
    info!("Trying to websocket connect!");
    future_to_promise(async move {
      info!("Now in future!");
      let mut connector = ButtplugRemoteClientConnector::<websocket_client_connector::ButtplugBrowserWebsocketClientTransport, ButtplugClientJSONSerializer>::new(websocket_client_connector::ButtplugBrowserWebsocketClientTransport::new("ws://127.0.0.1:12345/"));
      let (client, mut event_stream) = ButtplugClient::connect("WASM Client", connector)
        .await
        .unwrap();
        info!("Connected in future!");
      Ok(Self {
        client: Arc::new(client)
      }.into())
    }) 
  }

  pub fn start_scanning(&self) -> Promise {
    let client_clone = self.client.clone();
    future_to_promise(async move {
      client_clone.start_scanning().await.and_then(|_| Ok(JsValue::null())).map_err(|e| JsValue::from(format!("{}", e)))
    })
  }

  pub fn stop_scanning(&self) -> Promise {
    let client_clone = self.client.clone();
    future_to_promise(async move {
      client_clone.stop_scanning().await.and_then(|_| Ok(JsValue::null())).map_err(|e| JsValue::from(format!("{}", e)))
    })
  }
}
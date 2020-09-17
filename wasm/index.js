// Import our outputted wasm ES6 module
// Which, export default's, an initialization function
import init from "./pkg/buttplug_wasm.js";
import { ButtplugClientWASM } from "./pkg/buttplug_wasm.js";
console.log("HEWWO");
const runWasm = async () => {
  console.log("WHAT");
  // Instantiate our wasm module
  let bp = await init("./pkg/buttplug_wasm_bg.wasm");
  ButtplugClientWASM.scan_bluetooth().then((b) => console.log("Has bluetooth: " + b));
  // Call the Add function export from wasm, save the result
  console.log("connecting!");
  //const client = await bp.ButtplugClientWASM.connect();
  let client = await ButtplugClientWASM.connect_websocket();
  console.log("connected!");
  await client.start_scanning();
};
runWasm().then("Done!");
<script setup lang="ts">
import { MarkerType, useVueFlow, VueFlow } from "@vue-flow/core";
import CustomNode from "../components/CustomNode.vue";
import PlainNode from "~/components/PlainNode.vue";
import { useDataStore } from "~/stores/data";
import { storeToRefs } from "pinia";
import SecretNode from "~/components/SecretNode.vue";
import TheFooter from "~/components/TheFooter.vue";

const edgeLabelBgStyle = { fill: "skyblue" };

const route = useRoute();
const store = useDataStore();
const { plain, flow } = storeToRefs(store);

const data = flow;

const { nodes, setInteractive } = useVueFlow({
  fitViewOnInit: true,
  nodes: [
    {
      id: "secret",
      type: "secret",
      data: { title: "Secret" },
      position: { x: 335, y: 80 },
    },
    // Key Generation
    {
      id: "111",
      label: "Key Generation",
      position: { x: 300, y: 160 },
      style: {
        backgroundColor: "rgba(16, 185, 129, 0.5)",
        width: "220px",
        height: "850px",
      },
    },
    {
      id: "1",
      type: "custom",
      data: { title: "P10", indent1: "KeyGeneration", indent2: "P10" },
      parentNode: "111",
      position: { x: 40, y: 50 },
    },
    {
      id: "shift_1",
      label: "shift",
      position: { x: 10, y: 200 },
      style: {
        backgroundColor: "rgba(139, 92, 246, 0.5)",
        height: "100px",
        width: "200px",
      },
      parentNode: "111",
    },
    {
      id: "2",
      type: "custom",
      data: { title: "LS-1", indent1: "KeyGeneration", indent2: "LS1_L" },
      position: { x: 20, y: 30 },
      parentNode: "shift_1",
    },
    {
      id: "3",
      type: "custom",
      data: { title: "LS-1", indent1: "KeyGeneration", indent2: "LS1_R" },
      position: { x: 105, y: 30 },
      parentNode: "shift_1",
    },
    {
      id: "4",
      type: "custom",
      data: { title: "P8", indent1: "KeyGeneration", indent2: "P8_1" },
      position: { x: 55, y: 400 },
      parentNode: "111",
    },

    {
      id: "shift_2",
      label: "shift",
      position: { x: 10, y: 550 },
      style: {
        backgroundColor: "rgba(139, 92, 246, 0.5)",
        height: "100px",
        width: "200px",
      },
      parentNode: "111",
    },

    {
      id: "5",
      type: "custom",
      data: { title: "LS-2", indent1: "KeyGeneration", indent2: "LS2_L" },
      position: { x: 20, y: 30 },
      parentNode: "shift_2",
    },
    {
      id: "6",
      type: "custom",
      data: { title: "LS-2", indent1: "KeyGeneration", indent2: "LS2_R" },
      position: { x: 105, y: 30 },
      parentNode: "shift_2",
    },

    {
      id: "7",
      type: "custom",
      data: { title: "P8", indent1: "KeyGeneration", indent2: "P8_2" },
      position: { x: 55, y: 750 },
      parentNode: "111",
    },

    {
      id: "plain",
      type: "plain",
      position: { x: 50, y: -30 },
    },

    // Encryption
    {
      id: "en",
      label: "Encryption",
      position: { x: 0, y: 50 },
      style: {
        backgroundColor: "rgba(16, 185, 129, 0.5)",
        width: "220px",
        height: "1085px",
      },
      zIndex: -999,
    },

    {
      id: "8",
      type: "custom",
      data: {
        title: "IP",
        binary: data.value.Encryption.IP,
        indent1: "Encryption",
        indent2: "IP",
      },
      parentNode: "en",
      position: { x: 55, y: 35 },
    },

    {
      id: "fk_1",
      label: "FK",
      position: { x: 10, y: 100 },
      style: {
        backgroundColor: "rgba(139, 92, 246, 0.5)",
        height: "420px",
        width: "200px",
      },
      parentNode: "en",
      zIndex: -1000,
    },

    {
      id: "9",
      type: "custom",
      data: {
        title: "EP",
        binary: data.value.Encryption.FK_1.EP,
        indent1: "Encryption",
        indent2: "FK_1",
        indent3: "EP",
      },
      parentNode: "fk_1",
      position: { x: 50, y: 35 },
    },

    {
      id: "10",
      type: "custom",
      data: {
        title: "XOR",
        binary: data.value.Encryption.FK_1.XOR_1,
        indent1: "Encryption",
        indent2: "FK_1",
        indent3: "XOR_1",
      },
      parentNode: "fk_1",
      position: { x: 50, y: 115 },
    },

    {
      id: "11",
      type: "custom",
      data: {
        title: "Sbox",
        binary: data.value.Encryption.FK_1.Sbox,
        indent1: "Encryption",
        indent2: "FK_1",
        indent3: "Sbox",
      },
      parentNode: "fk_1",
      position: { x: 70, y: 195 },
    },

    {
      id: "13",
      type: "custom",
      data: {
        title: "P4",
        binary: data.value.Encryption.FK_1.P4,
        indent1: "Encryption",
        indent2: "FK_1",
        indent3: "P4",
      },
      parentNode: "fk_1",
      position: { x: 70, y: 275 },
    },

    {
      id: "14",
      type: "custom",
      data: {
        title: "XOR",
        binary: data.value.Encryption.FK_1.XOR_2,
        indent1: "Encryption",
        indent2: "FK_1",
        indent3: "XOR_2",
      },
      parentNode: "fk_1",
      position: { x: 75, y: 355 },
    },

    {
      id: "sw",
      type: "custom",
      data: {
        title: "SW",
        binary: data.value.Encryption.SW,
        indent1: "Encryption",
        indent2: "SW",
      },
      parentNode: "en",
      position: { x: 60, y: 530 },
    },

    {
      id: "fk_2",
      label: "FK",
      position: { x: 10, y: 590 },
      style: {
        backgroundColor: "rgba(139, 92, 246, 0.5)",
        height: "420px",
        width: "200px",
      },
      parentNode: "en",
      zIndex: -1000,
    },

    {
      id: "15",
      type: "custom",
      data: {
        title: "EP",
        indent1: "Encryption",
        indent2: "FK_2",
        indent3: "EP",
      },
      parentNode: "fk_2",
      position: { x: 50, y: 35 },
    },

    {
      id: "16",
      type: "custom",
      data: {
        title: "XOR",
        indent1: "Encryption",
        indent2: "FK_2",
        indent3: "XOR_1",
      },
      parentNode: "fk_2",
      position: { x: 50, y: 115 },
    },

    {
      id: "17",
      type: "custom",
      data: {
        title: "Sbox",
        indent1: "Encryption",
        indent2: "FK_2",
        indent3: "Sbox",
      },
      parentNode: "fk_2",
      position: { x: 70, y: 195 },
    },

    {
      id: "19",
      type: "custom",
      data: {
        title: "P4",
        indent1: "Encryption",
        indent2: "FK_2",
        indent3: "P4",
      },
      parentNode: "fk_2",
      position: { x: 70, y: 275 },
    },

    {
      id: "20",
      type: "custom",
      data: {
        title: "XOR",
        indent1: "Encryption",
        indent2: "FK_2",
        indent3: "XOR_2",
      },
      parentNode: "fk_2",
      position: { x: 70, y: 355 },
    },

    {
      id: "21",
      type: "custom",
      data: { title: "IP_1", indent1: "Encryption", indent2: "IP_1" },
      parentNode: "en",
      position: { x: 60, y: 1020 },
    },

    {
      id: "cipher",
      type: "custom",
      data: { title: "Cipher Text", indent1: "Encryption", indent2: "IP_1" },
      parentNode: "en",
      position: { x: 360, y: 1050 },
    },

    // Decryption
    {
      id: "dec",
      label: "Decryption",
      position: { x: 600, y: 50 },
      style: {
        backgroundColor: "rgba(16, 185, 129, 0.5)",
        width: "220px",
        height: "1085px",
      },
      zIndex: -999,
    },

    {
      id: "plain_1",
      type: "custom",
      data: { title: "Plain Text", indent1: "Decryption", indent2: "IP_1" },
      parentNode: "dec",
      position: { x: 55, y: -70 },
    },

    {
      id: "dec_ip_1",
      type: "custom",
      data: { title: "IP_1", indent1: "Decryption", indent2: "IP_1" },
      parentNode: "dec",
      position: { x: 55, y: 35 },
    },

    {
      id: "fk_21",
      label: "FK",
      position: { x: 10, y: 100 },
      style: {
        backgroundColor: "rgba(139, 92, 246, 0.5)",
        height: "420px",
        width: "200px",
      },
      parentNode: "dec",
      zIndex: -1000,
    },

    {
      id: "dec_2_xor_2",
      type: "custom",
      data: {
        title: "XOR",
        indent1: "Decryption",
        indent2: "FK_2",
        indent3: "XOR_2",
      },
      parentNode: "fk_21",
      position: { x: 75, y: 35 },
    },

    {
      id: "dec_2_p4",
      type: "custom",
      data: {
        title: "P4",
        indent1: "Decryption",
        indent2: "FK_2",
        indent3: "P4",
      },
      parentNode: "fk_21",
      position: { x: 70, y: 115 },
    },

    {
      id: "dec_2_sbox",
      type: "custom",
      data: {
        title: "Sbox",
        indent1: "Decryption",
        indent2: "FK_2",
        indent3: "Sbox",
      },
      parentNode: "fk_21",
      position: { x: 70, y: 195 },
    },

    {
      id: "dec_2_xor_1",
      type: "custom",
      data: {
        title: "XOR",
        indent1: "Decryption",
        indent2: "FK_2",
        indent3: "XOR_1",
      },
      parentNode: "fk_21",
      position: { x: 50, y: 275 },
    },

    {
      id: "dec_2_ep",
      type: "custom",
      data: {
        title: "EP",
        indent1: "Decryption",
        indent2: "FK_2",
        indent3: "EP",
      },
      parentNode: "fk_21",
      position: { x: 50, y: 355 },
    },

    {
      id: "sw_1",
      type: "custom",
      data: { title: "SW", indent1: "Decryption", indent2: "SW" },
      parentNode: "dec",
      position: { x: 60, y: 530 },
    },

    {
      id: "fk_12",
      label: "FK",
      position: { x: 10, y: 590 },
      style: {
        backgroundColor: "rgba(139, 92, 246, 0.5)",
        height: "420px",
        width: "200px",
      },
      parentNode: "dec",
      zIndex: -1000,
    },

    {
      id: "dec_1_xor_2",
      type: "custom",
      data: {
        title: "XOR",
        indent1: "Decryption",
        indent2: "FK_1",
        indent3: "XOR_2",
      },
      parentNode: "fk_12",
      position: { x: 70, y: 35 },
    },

    {
      id: "dec_1_p4",
      type: "custom",
      data: {
        title: "P4",
        indent1: "Decryption",
        indent2: "FK_1",
        indent3: "P4",
      },
      parentNode: "fk_12",
      position: { x: 70, y: 115 },
    },

    {
      id: "dec_1_sbox",
      type: "custom",
      data: {
        title: "Sbox",
        indent1: "Decryption",
        indent2: "FK_1",
        indent3: "Sbox",
      },
      parentNode: "fk_12",
      position: { x: 70, y: 195 },
    },

    {
      id: "dec_1_xor_1",
      type: "custom",
      data: {
        title: "XOR",
        indent1: "Decryption",
        indent2: "FK_1",
        indent3: "XOR_1",
      },
      parentNode: "fk_12",
      position: { x: 50, y: 275 },
    },

    {
      id: "dec_1_ep",
      type: "custom",
      data: {
        title: "EP",
        indent1: "Decryption",
        indent2: "FK_1",
        indent3: "EP",
      },
      parentNode: "fk_12",
      position: { x: 50, y: 355 },
    },

    {
      id: "dec_ip",
      type: "custom",
      data: { title: "IP", indent1: "Decryption", indent2: "IP" },
      parentNode: "dec",
      position: { x: 60, y: 1020 },
    },
  ],
  edges: [
    // Key Gen
    {
      id: "esecret-1",
      source: "secret",
      target: "1",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },

    {
      id: "e1-3",
      source: "1",
      target: "3",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e1-2",
      source: "1",
      target: "2",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e3-4",
      source: "3",
      target: "4",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e2-4",
      source: "2",
      target: "4",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e2-5",
      source: "2",
      target: "5",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e3-6",
      source: "3",
      target: "6",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e5-7",
      source: "5",
      target: "7",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e6-7",
      source: "6",
      target: "7",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },

    {
      id: "eplain-8",
      source: "plain",
      target: "8",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },

    {
      id: "e8-9",
      source: "8",
      target: "9",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e9-10",
      source: "9",
      target: "10",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e4-10",
      source: "4",
      target: "10",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      label: "Key 1",
      type: "step",
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e10-21",
      source: "10",
      target: "21",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      type: "straight",
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e7-16",
      source: "7",
      target: "16",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      type: "step",
      label: "Key 2",
      labelBgStyle: edgeLabelBgStyle,
    },

    {
      id: "eip-ep",
      source: "dec_ip",
      target: "dec_1_ep",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      type: "straight",
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "eep-xor_1",
      source: "dec_1_ep",
      target: "dec_1_xor_1",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      type: "straight",
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e7-xor_1",
      source: "7",
      target: "dec_1_xor_1",
      markerEnd: MarkerType.ArrowClosed,
      label: "Key 2",
      animated: true,
      type: "smoothstep",
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "e4-xor_1",
      source: "4",
      target: "dec_2_xor_1",
      markerEnd: MarkerType.ArrowClosed,
      label: "Key 1",
      animated: true,
      type: "smoothstep",
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "exor_1-dec_1_sbox",
      source: "dec_1_xor_1",
      target: "dec_ip_1",
      animated: true,
      type: "smoothstep",
      labelBgStyle: edgeLabelBgStyle,
    },

    {
      id: "e21-cipher",
      source: "21",
      target: "cipher",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      type: "smoothstep",
      labelBgStyle: edgeLabelBgStyle,
    },
    {
      id: "ecipher-22",
      source: "cipher",
      target: "dec_ip",
      markerEnd: MarkerType.ArrowClosed,
      animated: true,
      type: "smoothstep",
      labelBgStyle: edgeLabelBgStyle,
    },

    {
      id: "ecipher-22",
      source: "plain_1",
      target: "dec_ip_1",
      markerStart: MarkerType.ArrowClosed,
      animated: true,
      type: "smoothstep",
      labelBgStyle: edgeLabelBgStyle,
    },
  ],
});

onMounted(() => {
  if (route.query.plain) {
    store.setPlain(route.query.plain as string);
    if (route.query.secret?.length === 10)
      store.setSecret(route.query.secret as string);
  }
});

setInteractive(false);

nodes.value.find((a) => a.id === "secret")!.selectable = true;
nodes.value.find((a) => a.id === "plain")!.selectable = true;
</script>

<template>
  <div class="pointer-events-none">
    <div class="flex justify-center items-center" style="height: 700px">
      <vue-flow>
        <template #node-custom="{ data }">
          <custom-node :data="data" />
        </template>
        <template #node-plain="{ data }">
          <plain-node :data="data" />
        </template>
        <template #node-secret="{ data }">
          <secret-node :data="data" />
        </template>
      </vue-flow>
    </div>
  </div>
  <main class="px-4 py-10 text-center text-gray-700 dark:text-gray-200">
    <the-footer />
  </main>
</template>

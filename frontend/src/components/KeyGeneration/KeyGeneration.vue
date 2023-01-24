<script setup lang="ts">
import data from './../../../data.json'
import TheBox from "~/components/TheBox.vue";

console.log(data.KeyGeneration)

</script>

<template>
 <div>
   <the-box title="P10" :binary="data.KeyGeneration.P10" name="p10"/>
   <div class="flex flex-col">
     <the-box title="P10" :binary="data.KeyGeneration.P10" name="ls1_l"/>
     <the-box name="ls1_r"/>
   </div>
   <div>
     <the-box name="p8_1"/>
   </div>
   <div>
     <the-box name="ls2_l"/>
     <the-box name="ls2_r"/>
   </div>
   <div>
     <the-box name="p8_2"/>
   </div>
 </div>


</template>

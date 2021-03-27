<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <p>Welcome to Your Vue.js + TypeScript App</p>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class Home extends Vue {}
</script>

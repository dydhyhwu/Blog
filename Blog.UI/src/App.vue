<template>
    <v-app>
        <router-view></router-view>
    </v-app>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';

    @Component
    export default class AppEntry extends Vue {}
</script>

<template>
    <div class="full-height">
        <v-app-bar color="primary" hide-on-scroll dense app dark>
            <v-toolbar-title>心情题解</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-btn text>
                <v-icon>mdi-home</v-icon>
                首页
            </v-btn>
            <v-btn text>
                <v-icon>mdi-account</v-icon>
                关于
            </v-btn>
        </v-app-bar>
        <v-main>
            <router-view></router-view>
        </v-main>
    </div>
</template>

<script>
    import { Component, Vue } from 'vue-property-decorator';

    @Component
    export default class WebLayout extends Vue {}
</script>

<style scoped></style>

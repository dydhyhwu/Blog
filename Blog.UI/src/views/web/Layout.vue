<template>
    <div class="full-height">
        <v-app-bar color="primary" hide-on-scroll dense app dark>
            <v-toolbar-title>心情题解</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-btn text depressed @click="toHome">
                <v-icon>mdi-home</v-icon>
                首页
            </v-btn>
            <v-btn text>
                <v-icon>mdi-account</v-icon>
                关于
            </v-btn>
        </v-app-bar>
        <v-main>
            <v-slide-x-reverse-transition>
                <router-view></router-view>
            </v-slide-x-reverse-transition>
        </v-main>
    </div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { Home } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';

    @Component
    export default class WebLayout extends BasePage {
        toHome(): void {
            this.navigator.redirect(Home);
        }
    }
</script>

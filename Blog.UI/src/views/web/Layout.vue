<template>
    <div class="full-height">
        <v-app-bar color="primary" hide-on-scroll dense app dark>
            <v-toolbar-title>心情题解</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-btn v-bind="btnProps" @click="toHome">
                <v-icon>mdi-home</v-icon>
                首页
            </v-btn>
            <v-btn v-bind="btnProps" :to="categories">分类</v-btn>
            <v-btn v-bind="btnProps">导航</v-btn>
            <v-btn v-bind="btnProps">
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
    import { Home, Categories } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';

    @Component
    export default class WebLayout extends BasePage {
        btnProps = {
            text: true,
            depressed: true,
        };

        get categories() {
            return this.getRoute(Categories);
        }

        toHome(): void {
            this.navigator.redirect(Home);
        }

        getRoute(name: string) {
            return {
                name: name,
            };
        }
    }
</script>

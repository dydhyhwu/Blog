<template>
    <div class="full-height">
        <v-app-bar color="blue" app flat clipped-left dark>
            <v-app-bar-nav-icon @click="toggleNav"></v-app-bar-nav-icon>
            <v-app-bar-title>心情题解の小秘密</v-app-bar-title>
        </v-app-bar>
        <v-navigation-drawer v-model="navVisible" app clipped hide-overlay>
            <Menu :menu="menu"></Menu>
            <template #append>
                <div class="ma-2">
                    <v-btn color="primary" outlined block>设置</v-btn>
                </div>
            </template>
        </v-navigation-drawer>
        <v-main class="main-content full-height">
            <v-container fluid class="full-height">
                <v-slide-y-reverse-transition>
                    <router-view class="main-content-view pa-5"></router-view>
                </v-slide-y-reverse-transition>
            </v-container>
        </v-main>
    </div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import { AdminNavMenu } from '@/infrastructure/const/adminNavMenu';
    import Menu from '@/components/Menu.vue';

    @Component({
        components: { Menu },
    })
    export default class AdminLayoutPageComponent extends Vue {
        readonly menu = AdminNavMenu;
        navVisible = false;

        toggleNav(): void {
            this.navVisible = !this.navVisible;
        }
    }
</script>

<style scoped>
    .main-content {
        background-color: #f0f2f5;
    }
    .main-content-view {
        background-color: #fff;
    }
</style>

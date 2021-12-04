<template>
    <div class="full-height">
        <v-app-bar hide-on-scroll dense app>
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
    export default {
        name: 'Layout',
    };
</script>

<style scoped></style>

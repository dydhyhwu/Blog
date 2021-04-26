<template>
    <div class="fill-height">
        <v-app-bar color="white" app flat>心情题解</v-app-bar>
        <v-main class="grey lighten-3 fill-height">
            <v-container>
                <v-row>
                    <v-col cols="2">
                        <v-sheet rounded>
                            <v-list color="transparent">
                                <v-list-item>
                                    <v-list-item-content>
                                        <v-list-item-title>
                                            分类1
                                        </v-list-item-title>
                                    </v-list-item-content>
                                </v-list-item>

                                <v-list-item>
                                    <v-list-item-content>
                                        <v-list-item-title>
                                            分类2
                                        </v-list-item-title>
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list>
                        </v-sheet>
                    </v-col>
                    <v-col>
                        <v-sheet rounded min-height="80vh"></v-sheet>
                    </v-col>
                </v-row>
            </v-container>
        </v-main>
    </div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { Home } from '@/domain/views';

    @RouteName(Home)
    @Component
    export default class HomePage extends Vue {}
</script>

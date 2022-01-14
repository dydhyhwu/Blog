<template>
    <div class="full-height">
        <v-container class="d-flex">
            <v-card
                v-for="(link, index) in list"
                :key="index"
                class="link-card mx-3"
            >
                <v-card-subtitle>{{ link.title }}</v-card-subtitle>
                <v-card-text>
                    {{ link.description }}
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                        small
                        color="primary"
                        :href="link.content"
                        target="_blank"
                    >
                        去看看
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-container>
    </div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { Links } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { FavoriteLink } from '@/models/FavoriteLink';

    @RouteName(Links)
    @Component
    export default class NavigatePage extends BasePage {
        list: FavoriteLink[] = [];

        mounted(): void {
            this.loadData();
        }

        private async loadData(): Promise<void> {
            this.list = await this.repository.FavoriteLink.All();
        }
    }
</script>

<style lang="css" scoped>
    .link-card {
        width: 300px;
    }
</style>

<template>
    <div class="full-height">
        <v-data-table :headers="headers" :items="links" hide-default-footer>
            <template #top>
                <v-row no-gutters align="center" class="mx-2">
                    <v-col>
                        <v-btn color="blue" tile dark :to="AddLinkRoute">
                            <v-icon small>mdi-plus</v-icon>
                            新增
                        </v-btn>
                    </v-col>
                    <v-spacer></v-spacer>
                    <div></div>
                </v-row>
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AddFavoriteLink, LinkManage } from '@/domain/views';
    import { FavoriteLink } from '@/models/FavoriteLink';
    import { Page } from '@/domain/page';
    import BasePage from '@/infrastructure/basePage';

    @RouteName(LinkManage)
    @Component
    export default class extends BasePage {
        headers = [
            {
                text: '标题',
                value: 'title',
            },
            {
                text: '简介',
                value: 'description',
            },
            {
                text: '创建时间',
                value: 'createTime',
            },
        ];
        links: FavoriteLink[] = [];
        page: Page = new Page();

        get AddLinkRoute() {
            return {
                name: AddFavoriteLink,
            };
        }

        mounted() {
            this.init();
        }

        async init() {
            let response = await this.repository.FavoriteLink.List(this.page);
            this.page.count = response.count;
            this.page.page = response.page;
            this.links = response.data;
        }
    }
</script>

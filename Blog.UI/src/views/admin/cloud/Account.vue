<template>
    <div class="full-height">
        <v-data-table
            :headers="headers"
            :items="items"
            :loading="loading"
            hide-default-footer
        >
            <template #top>
                <v-row no-gutters align="center" class="mx-2">
                    <v-col>
                        <v-btn color="blue" tile dark>
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
    import { Component, Inject } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { CloudAccountManage } from '@/domain/views';
    import { CloudAccount } from '@/models/Cloud';
    import BasePage from '@/infrastructure/basePage';
    import { Repository } from '../../../domain/providers';
    import { Repositories } from '../../../infrastructure/repository';

    @RouteName(CloudAccountManage)
    @Component
    export default class CloudAccountManagePage extends BasePage {
        @Inject(Repository) repository: Repositories;

        loading = false;

        headers = [
            { text: '名称', value: 'name' },
            { text: 'AppId', value: 'appId' },
            { text: '创建时间', value: 'createTime' },
            { text: '操作', value: 'options' },
        ];

        items: CloudAccount[] = [];

        mounted(): void {
            this.getAccountList();
        }

        private async getAccountList(): Promise<void> {
            try {
                this.loading = true;
                this.items = await this.repository.CloudAccount.List();
            } finally {
                this.loading = false;
            }
        }
    }
</script>

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
                        <v-btn color="blue" tile dark @click="showAddDialog">
                            <v-icon small>mdi-plus</v-icon>
                            新增
                        </v-btn>
                    </v-col>
                    <v-spacer></v-spacer>
                    <div></div>
                </v-row>
            </template>

            <template #item.options="{ item }">
                <div>
                    <v-btn text small depressed>编辑</v-btn>
                    <v-btn
                        color="error"
                        text
                        small
                        depressed
                        @click="remove(item)"
                    >
                        删除
                    </v-btn>
                </div>
            </template>
        </v-data-table>

        <v-dialog v-model="addDialog" width="40%" persistent>
            <v-card class="mx-auto">
                <v-card-title>添加云账号</v-card-title>
                <v-card-text>
                    <v-text-field
                        v-model="addItem.name"
                        label="名称"
                        placeholder="请输入名称"
                    ></v-text-field>

                    <v-text-field
                        v-model="addItem.appId"
                        label="appId"
                        placeholder="请输入appId"
                    ></v-text-field>

                    <v-text-field
                        v-model="addItem.secretId"
                        label="secretId"
                        placeholder="请输入secretId"
                    ></v-text-field>

                    <v-text-field
                        v-model="addItem.secretKey"
                        label="secretKey"
                        placeholder="请输入secretKey"
                    ></v-text-field>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="primary" @click="submit">提交</v-btn>
                    <v-btn color="error" @click="cancelAdd">取消</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
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
    import { Confirm, OnFinishedSuccess } from '@dydhyh/ui-tools';

    @RouteName(CloudAccountManage)
    @Component
    export default class CloudAccountManagePage extends BasePage {
        @Inject(Repository) repository: Repositories;

        loading = false;

        addDialog = false;

        addItem = {
            name: '',
            appId: '',
            secretId: '',
            secretKey: '',
        };

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

        @OnFinishedSuccess('添加成功')
        async submit(): Promise<void> {
            await this.repository.CloudAccount.Add(this.addItem);
            this.addItem = {
                name: '',
                appId: '',
                secretId: '',
                secretKey: '',
            };
            this.addDialog = false;
            await this.getAccountList();
        }

        showAddDialog(): void {
            this.addDialog = true;
        }

        cancelAdd(): void {
            this.addDialog = false;
        }

        @Confirm('是否删除,删除后不可恢复')
        @OnFinishedSuccess('删除成功')
        async remove(item: CloudAccount): Promise<void> {
            await this.repository.CloudAccount.Remove(item.id);
            await this.getAccountList();
        }
    }
</script>

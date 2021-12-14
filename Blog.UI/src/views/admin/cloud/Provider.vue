<template>
    <div class="full-height">
        <v-data-table :headers="headers" :items="items" hide-default-footer>
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
        </v-data-table>

        <v-dialog v-model="addDialog" persistent width="40%">
            <v-card class="mx-auto">
                <v-card-title>添加云存储</v-card-title>
                <v-card-text>
                    <v-select
                        v-model="curAccount"
                        :items="accounts"
                        return-object
                        item-text="name"
                        label="云账号"
                    ></v-select>

                    <v-text-field
                        v-model="addItem.name"
                        label="名称"
                        placeholder="请输入名称"
                    >
                        <template #append>
                            <span class="mx-1">-</span>
                            {{ curAccount.appId }}
                        </template>
                    </v-text-field>

                    <v-text-field
                        v-model="addItem.region"
                        label="所属地域"
                        placeholder="请输入存储所属地域"
                    ></v-text-field>

                    <v-text-field
                        v-model="addItem.duration"
                        type="number"
                        label="临时凭证有效期"
                        placeholder="单位为秒，默认为1800"
                    >
                        <template #append>秒</template>
                    </v-text-field>
                    <v-text-field
                        v-model="addItem.allowPrefix"
                        label="路径权限"
                        placeholder="如：abc/*,photos/*"
                    ></v-text-field>

                    <v-combobox
                        v-model="addItem.allowActions"
                        :items="actions"
                        item-value="value"
                        label="操作权限"
                        multiple
                        small-chips
                    ></v-combobox>
                </v-card-text>

                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="success" @click="submit">确认</v-btn>
                    <v-btn color="error" @click="cancelAdd">取消</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script lang="ts">
    import { Component, Inject } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { CloudProviderManage } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { Repository } from '../../../domain/providers';
    import { Repositories } from '../../../infrastructure/repository';
    import {
        AddCosProvider,
        CloudAccount,
        CosProviderListItem,
        StsClientAction,
    } from '../../../models/Cloud';
    import { OnFinishedSuccess, WithLoading } from '@dydhyh/ui-tools';

    @RouteName(CloudProviderManage)
    @Component
    export default class CloudProviderManagePage extends BasePage {
        @Inject(Repository) repository: Repositories;

        headers = [
            { text: 'ID', value: 'id' },
            {
                text: '名称',
                value: 'bucketName',
            },
            {
                text: '区域',
                value: 'region',
            },
            {
                text: '路径权限',
                value: 'allowPrefix',
            },
            {
                text: '操作权限',
                value: 'allowActions',
            },
            {
                text: '操作',
                value: 'options',
            },
        ];

        addDialog = false;
        addItem: AddCosProvider = {
            allowActions: [],
            allowPrefix: '',
            accountId: '',
            duration: 0,
            name: '',
            region: '',
        };
        curAccount: CloudAccount = {
            appId: '',
            createTime: '',
            id: '',
            name: '',
        };

        items: CosProviderListItem[] = [];
        accounts: CloudAccount[] = [];
        actions = [
            { text: '简单上传', value: StsClientAction.NormalUpload },
            {
                text: '表单和小程序上传',
                value: StsClientAction.FormOrMiniUpload,
            },
            {
                text: '分片上传',
                value: StsClientAction.MultipartUpload,
            },
        ];

        mounted(): void {
            this.getAccountList();
            this.getProviderList();
        }

        private async getAccountList(): Promise<void> {
            this.accounts = await this.repository.CloudAccount.List();
        }

        @WithLoading('加载中')
        private async getProviderList(): Promise<void> {
            this.items = await this.repository.CosProvider.List();
        }

        showAddDialog(): void {
            this.addDialog = true;
        }

        cancelAdd(): void {
            this.addDialog = false;
        }

        @OnFinishedSuccess('添加成功')
        async submit(): Promise<void> {
            await this.repository.CosProvider.Add(this.addItem);
            this.addItem = {
                accountId: '',
                allowActions: [],
                allowPrefix: '',
                duration: 0,
                name: '',
                region: '',
            };

            this.addDialog = false;

            this.getProviderList();
        }
    }
</script>

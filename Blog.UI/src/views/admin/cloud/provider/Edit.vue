<template>
    <div class="full-height">
        <v-card class="mx-auto" width="30%">
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
                    v-model="provider.bucketName"
                    label="名称"
                    placeholder="请输入名称"
                >
                    <template #append>
                        <span class="mx-1">-</span>
                        {{ curAccount.appId }}
                    </template>
                </v-text-field>

                <v-text-field
                    v-model="provider.region"
                    label="所属地域"
                    placeholder="请输入存储所属地域"
                ></v-text-field>

                <v-text-field
                    v-model="provider.uploadPrefix"
                    label="上传路径"
                    placeholder="指定文件上传的路径，末尾不需要/"
                ></v-text-field>

                <v-text-field
                    v-model="provider.host"
                    label="域名"
                    placeholder="指定存储文件上传之后的访问域名"
                ></v-text-field>

                <v-text-field
                    v-model="provider.duration"
                    type="number"
                    label="临时凭证有效期"
                    placeholder="单位为秒，默认为1800"
                >
                    <template #append>秒</template>
                </v-text-field>
                <v-text-field
                    v-model="provider.allowPrefix"
                    label="路径权限"
                    placeholder="如：abc/*,photos/*"
                ></v-text-field>

                <v-select
                    v-model="provider.allowActions"
                    :items="actions"
                    label="操作权限"
                    multiple
                    small-chips
                ></v-select>
            </v-card-text>

            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="success" @click="submit">确认</v-btn>
                <v-btn color="error" @click="toManagePage">取消</v-btn>
            </v-card-actions>
        </v-card>
    </div>
</template>

<script lang="ts">
    import { Component, Inject, Prop } from 'vue-property-decorator';
    import { Context, EnableProp, RouteName } from 'ea-router';
    import { CloudProviderEdit, CloudProviderManage } from '@/domain/views';
    import BasePage from '@/infrastructure/basePage';
    import { Navigator, Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import {
        CloudAccount,
        CosProviderDetail,
        StsClientAction,
    } from '@/models/Cloud';
    import { OnFinishedSuccess, WithLoading } from '@dydhyh/ui-tools';
    import { Navigation } from '../../../../infrastructure/navigator';

    @RouteName(CloudProviderEdit)
    @Context('id')
    @EnableProp()
    @Component
    export default class CloudProviderEditPage extends BasePage {
        @Inject(Repository) repository: Repositories;
        @Inject(Navigator) navigator: Navigation;

        @Prop({ type: String, default: () => '' }) readonly id: string;

        provider: CosProviderDetail = {
            accountId: '',
            allowActions: [],
            allowPrefix: '',
            bucketName: '',
            duration: 0,
            host: '',
            id: '',
            region: '',
            uploadPrefix: '',
        };

        accounts: CloudAccount[] = [];

        curAccount: CloudAccount = {
            appId: '',
            createTime: '',
            id: '',
            name: '',
        };

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

        mounted() {
            this.init();
        }

        @WithLoading('加载中')
        private async init(): Promise<void> {
            await this.getAccountList();
            await this.getData();
            this.curAccount = this.accounts.find(
                (x) => x.id === this.provider.accountId
            );
        }

        private async getData(): Promise<void> {
            this.provider = await this.repository.CosProvider.Detail(this.id);
        }

        private async getAccountList(): Promise<void> {
            this.accounts = await this.repository.CloudAccount.List();
        }

        @WithLoading('保存中')
        @OnFinishedSuccess('保存成功')
        async submit(): Promise<void> {
            await this.repository.CosProvider.Edit(this.provider);
            this.toManagePage();
        }

        private toManagePage() {
            this.navigator.redirect(CloudProviderManage);
        }
    }
</script>

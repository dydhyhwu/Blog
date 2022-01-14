<template>
    <div class="full-height">
        <v-data-table
            :headers="headers"
            :items="categories"
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
                    <v-btn small text depressed>编辑</v-btn>
                    <v-btn
                        color="error"
                        small
                        text
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
                <v-card-title>添加类别</v-card-title>
                <v-card-text>
                    <v-text-field
                        v-model="addName"
                        label="类别名称"
                        placeholder="请填写类别名称"
                    ></v-text-field>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="primary" @click="add">添加</v-btn>
                    <v-btn color="error" @click="cancelAdd">取消</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { CategoryManage } from '@/domain/views';
    import { ArticleListItem } from '@/models/Article';
    import { Page } from '@/domain/page';
    import BasePage from '@/infrastructure/basePage';
    import { Confirm, OnFinishedSuccess, WithLoading } from '@dydhyh/ui-tools';
    import { Category } from '@/domains/Category';

    @RouteName(CategoryManage)
    @Component
    export default class CategoryManagePage extends BasePage {
        headers = [
            {
                text: '名称',
                value: 'name',
            },
            {
                text: '创建时间',
                value: 'createTime',
            },
            {
                text: '操作',
                value: 'options',
            },
        ];
        categories: Category[] = [];
        page: Page = new Page();

        addDialog = false;
        addName = '';

        mounted(): void {
            this.init();
        }

        @WithLoading('加载中')
        async init(): Promise<void> {
            let response = await this.repository.Category.List(this.page);
            this.page.count = response.count;
            this.page.page = response.page;
            this.categories = response.data;
        }

        @Confirm('是否删除,删除后不可恢复')
        @OnFinishedSuccess('删除成功')
        async remove(item: ArticleListItem): Promise<void> {
            await this.repository.Category.Delete(item.id);
            await this.init();
        }

        showAddDialog(): void {
            this.addDialog = true;
        }

        @OnFinishedSuccess('添加成功')
        async add(): Promise<void> {
            await this.repository.Category.Add(this.addName);
            this.addName = '';
            this.addDialog = false;
            await this.init();
        }

        cancelAdd(): void {
            this.addDialog = false;
        }
    }
</script>

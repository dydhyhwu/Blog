<template>
    <div>
        <v-container>
            <v-row>
                <v-text-field
                    v-model="link.title"
                    placeholder="起一个独一无二的名字吧"
                ></v-text-field>
            </v-row>
            <v-row>
                <v-text-field
                    v-model="link.content"
                    placeholder="快把它复制下来！"
                ></v-text-field>
            </v-row>
            <v-row>
                <v-textarea
                    v-model="link.description"
                    placeholder="这是一个什么样的站点呢？"
                ></v-textarea>
            </v-row>
            <v-row>
                <v-spacer></v-spacer>
                <v-btn @click="save">添加</v-btn>
            </v-row>
        </v-container>
    </div>
</template>

<script lang="ts">
    import { Component } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AddFavoriteLink } from '@/domain/views';
    import { FavoriteLink } from '@/models/FavoriteLink';
    import BasePage from '@/infrastructure/basePage';

    @RouteName(AddFavoriteLink)
    @Component
    export default class AddFavoriteLinkPage extends BasePage {
        link: FavoriteLink = new FavoriteLink();

        async save() {
            await this.repository.FavoriteLink.add(this.link);
            this.message.success('添加成功');
        }
    }
</script>

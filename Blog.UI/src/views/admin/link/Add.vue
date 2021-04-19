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
    import { Vue, Component, Inject } from 'vue-property-decorator';
    import { RouteName } from 'ea-router';
    import { AddFavoriteLink } from '@/domain/views';
    import { FavoriteLink } from '@/models/FavoriteLink';
    import { Navigator, Repository } from '@/domain/providers';
    import { Repositories } from '@/infrastructure/repository';
    import { Notification } from 'vuetify-extension';
    import { Navigation } from '@/infrastructure/navigator';

    @RouteName(AddFavoriteLink)
    @Component
    export default class AddFavoriteLinkPage extends Vue {
        @Inject(Repository) repository: Repositories;
        @Inject(Navigator) navigator: Navigation;

        link: FavoriteLink = new FavoriteLink();

        async save() {
            await this.repository.FavoriteLink.add(this.link);
            Notification.success('添加成功');
        }
    }
</script>

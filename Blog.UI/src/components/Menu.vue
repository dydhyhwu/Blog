<template>
    <v-list nav dense>
        <div v-for="(menuItem, index) in menu" :key="index">
            <v-list-item v-if="!menuItem.children" :to="getRoute(menuItem)">
                <v-list-item-icon v-if="menuItem.icon">
                    <v-icon>{{ menuItem.icon }}</v-icon>
                </v-list-item-icon>
                <v-list-item-content>
                    <v-list-item-title>{{ menuItem.title }}</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
            <v-list-group v-else :prepend-icon="menuItem.icon">
                <template #activator>
                    <v-list-item-title>{{ menuItem.title }}</v-list-item-title>
                </template>
                <dynamic-menu :menu="menuItem.children"></dynamic-menu>
            </v-list-group>
        </div>
    </v-list>
</template>

<script lang="ts">
    import { Vue, Component, Prop } from 'vue-property-decorator';
    import { MenuItem } from '@/domain/menuItem';

    @Component({
        name: 'DynamicMenu'
    })
    export default class DynamicMenu extends Vue {
        @Prop() menu: MenuItem[];

        getRoute(item: MenuItem) {
            if (item.routeName) {
                return {
                    name: item.routeName,
                };
            }
            return undefined;
        }
    }
</script>

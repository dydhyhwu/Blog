import { MenuItem } from '@/domain/menuItem';
import { AddArticle, AddFavoriteLink, AdminHome } from '@/domain/views';

export const AdminNavMenu: MenuItem[] = [
    {
        icon: 'mdi-home',
        title: '首页',
        routeName: AdminHome,
    },
    {
        icon: 'mdi-content',
        title: '内容管理',
        children: [
            {
                icon: 'mdi-content',
                title: '文章管理',
                routeName: AddArticle,
            },
            {
                icon: 'mdi-website',
                title: '收藏链接',
                routeName: AddFavoriteLink,
            },
        ],
    },
];

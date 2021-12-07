import { MenuItem } from '@/domain/menuItem';
import {
    AdminHome,
    ArticleManage,
    CategoryManage,
    LinkManage,
} from '@/domain/views';

export const AdminNavMenu: MenuItem[] = [
    {
        icon: 'mdi-home',
        title: '首页',
        routeName: AdminHome,
    },
    {
        icon: 'mdi-table-of-contents',
        title: '内容管理',
        children: [
            {
                icon: 'mdi-file-document',
                title: '文章管理',
                routeName: ArticleManage,
            },
            {
                icon: 'mdi-link',
                title: '收藏链接',
                routeName: LinkManage,
            },
        ],
    },
    {
        icon: 'mdi-table-of-contents',
        title: '类别管理',
        routeName: CategoryManage,
    },
];

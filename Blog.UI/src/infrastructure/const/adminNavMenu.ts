import { MenuItem } from '@/domain/menuItem';
import {
    AdminHome,
    ArticleManage,
    CategoryManage,
    CloudAccountManage,
    CloudProviderManage,
    CodeSnippetManage,
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
                title: '代码片段',
                routeName: CodeSnippetManage,
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
    {
        icon: 'mdi-cog-outline',
        title: '云服务设置',
        children: [
            {
                icon: 'mdi-cog',
                title: '云账号管理',
                routeName: CloudAccountManage,
            },
            {
                icon: 'mdi-cog',
                title: '存储管理',
                routeName: CloudProviderManage,
            },
        ],
    },
];

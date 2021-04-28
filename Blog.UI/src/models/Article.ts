export interface ArticleListItem {
    id: string;
    title: string;
    createTime: string;
}

export interface Article {
    id?: string;
    title: string;
    content: string;
    format?: ContentFormat;
    createTime?: string;
}

export enum ContentFormat {
    Markdown,
    Html,
}

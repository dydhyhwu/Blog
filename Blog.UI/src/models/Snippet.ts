/**
 * 列表展示
 */
export interface SnippetItem {
    id: string;
    title: string;
    language: string;
    createTime: string;
}

/**
 * 新增
 */
export interface AddSnippet {
    title: string;
    language: string;
    content: string;
}

/**
 * 编辑
 */
export interface EditSnippet {
    id: string;
    title: string;
    language: string;
    content: string;
}

/**
 * 详情
 */
export interface Snippet {
    id: string;
    title: string;
    language: string;
    content: string;
    createTime: string;
}

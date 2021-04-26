export interface PageData<T> {
    count: number;
    page: number;
    index: number;
    size: number;
    data: T[];
}

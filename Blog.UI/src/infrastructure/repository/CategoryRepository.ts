import { Page } from '@/domain/page';
import { PageData } from '@/models/Page';
import { Category } from '@/domains/Category';
import AxiosHttp from '@/infrastructure/http';

export default class CategoryRepository {
    Add(name: string): Promise<void> {
        const data = {
            name: name,
        };
        return AxiosHttp.Instance.post('/Category/Add', data);
    }

    List(query: Page): Promise<PageData<Category>> {
        return AxiosHttp.Instance.get('/Category/List', query);
    }

    async Delete(id: string): Promise<void> {
        const data = {
            id: id,
        };
        return AxiosHttp.Instance.post('/Category/Delete', data);
    }

    async All(): Promise<Category[]> {
        return AxiosHttp.Instance.get('/Category/All');
    }
}

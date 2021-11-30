import { Page } from '@/domain/page';
import AxiosHttp from '@/infrastructure/http';
import { PageData } from '@/models/Page';
import { Article, ArticleEditModel, ArticleListItem } from '@/models/Article';

export default class ArticleRepository {
    List(page: Page) {
        return AxiosHttp.Instance.get<PageData<ArticleListItem>>(
            '/Article/List',
            page
        );
    }

    Get(id: string) {
        const param = {
            id: id,
        };
        return AxiosHttp.Instance.get<Article>('/Article/Get', param);
    }

    async Add(article: Article) {
        return AxiosHttp.Instance.post('/Article/Add', article);
    }

    async Detail(id: string): Promise<ArticleEditModel> {
        const param = {
            id: id,
        };
        return AxiosHttp.Instance.get<ArticleEditModel>(
            '/Article/Detail',
            param
        );
    }

    async Edit(model: ArticleEditModel): Promise<void> {
        return AxiosHttp.Instance.post('/Article/Edit', model);
    }

    async Delete(id: string): Promise<void> {
        const data = {
            id: id,
        };
        return AxiosHttp.Instance.post('/Article/Delete', data);
    }
}

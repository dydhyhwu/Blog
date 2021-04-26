import { Page } from '@/domain/page';
import AxiosHttp from '@/infrastructure/http';
import { PageData } from '@/models/Page';
import { ArticleListItem } from '@/models/Article';

export default class ArticleRepository {
    List(page: Page) {
        return AxiosHttp.Instance.get<PageData<ArticleListItem>>(
            '/Article/List',
            page
        );
    }
}

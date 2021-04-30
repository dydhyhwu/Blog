import AxiosHttp from '@/infrastructure/http';
import { FavoriteLink } from '@/models/FavoriteLink';
import { Page } from '@/domain/page';
import { PageData } from '@/models/Page';

export class FavoriteLinkRepository {
    get(id: string) {
        const query = {
            id: id,
        };
        return AxiosHttp.Instance.get<FavoriteLink>('/FavoriteLink/Get', query);
    }

    add(link: FavoriteLink) {
        const data = {
            title: link.title,
            description: link.description,
            content: link.content,
        };
        return AxiosHttp.Instance.post('/FavoriteLink/Add', data);
    }

    List(page: Page) {
        return AxiosHttp.Instance.get<PageData<FavoriteLink>>(
            '/FavoriteLink/List',
            page
        );
    }
}

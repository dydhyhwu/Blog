import AxiosHttp from '@/infrastructure/http';
import { FavoriteLink } from '@/models/FavoriteLink';

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
}

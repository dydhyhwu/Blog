import { FavoriteLinkRepository } from '@/infrastructure/repository/FavoriteLinkRepository';
import ArticleRepository from '@/infrastructure/repository/ArticleRepository';

export interface Repositories {
    FavoriteLink: FavoriteLinkRepository;
    Article: ArticleRepository;
}

export default class RepositoryImpl implements Repositories {
    FavoriteLink: FavoriteLinkRepository = new FavoriteLinkRepository();
    Article: ArticleRepository = new ArticleRepository();
}

import { FavoriteLinkRepository } from '@/infrastructure/repository/FavoriteLinkRepository';
import ArticleRepository from '@/infrastructure/repository/ArticleRepository';
import CategoryRepository from '@/infrastructure/repository/CategoryRepository';
import CloudAccountRepository from './CloudAccountRepository';

export interface Repositories {
    CloudAccount: CloudAccountRepository;
    Category: CategoryRepository;
    FavoriteLink: FavoriteLinkRepository;
    Article: ArticleRepository;
}

export default class RepositoryImpl implements Repositories {
    Category = new CategoryRepository();
    FavoriteLink: FavoriteLinkRepository = new FavoriteLinkRepository();
    Article: ArticleRepository = new ArticleRepository();
    CloudAccount = new CloudAccountRepository();
}

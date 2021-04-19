import { FavoriteLinkRepository } from '@/infrastructure/repository/FavoriteLinkRepository';

export interface Repositories {
    FavoriteLink: FavoriteLinkRepository;
}

export default class RepositoryImpl implements Repositories {
    FavoriteLink: FavoriteLinkRepository = new FavoriteLinkRepository();
}

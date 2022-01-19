import { FavoriteLinkRepository } from '@/infrastructure/repository/FavoriteLinkRepository';
import ArticleRepository from '@/infrastructure/repository/ArticleRepository';
import CategoryRepository from '@/infrastructure/repository/CategoryRepository';
import CloudAccountRepository from './CloudAccountRepository';
import CosProviderRepository from './CosProviderRepository';
import CodeSnippetRepository from './CodeSnippetRepository';

export interface Repositories {
    CosProvider: CosProviderRepository;
    CloudAccount: CloudAccountRepository;
    Category: CategoryRepository;
    FavoriteLink: FavoriteLinkRepository;
    Article: ArticleRepository;
    Snippet: CodeSnippetRepository;
}

export default class RepositoryImpl implements Repositories {
    Category = new CategoryRepository();
    FavoriteLink: FavoriteLinkRepository = new FavoriteLinkRepository();
    Article: ArticleRepository = new ArticleRepository();
    CloudAccount = new CloudAccountRepository();
    CosProvider: CosProviderRepository = new CosProviderRepository();
    Snippet: CodeSnippetRepository = new CodeSnippetRepository();
}

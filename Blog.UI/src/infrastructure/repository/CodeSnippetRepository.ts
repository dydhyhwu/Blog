import { Page } from '../../domain/page';
import { AddSnippet, SnippetItem } from '../../models/Snippet';
import AxiosHttp from '../http';
import { PageData } from '../../models/Page';

export default class CodeSnippetRepository {
    List(page: Page): Promise<PageData<SnippetItem>> {
        return AxiosHttp.Instance.get('/CodeSnippet/List', page);
    }

    Add(snippet: AddSnippet) {
        return AxiosHttp.Instance.post('/CodeSnippet/Add', snippet);
    }
}

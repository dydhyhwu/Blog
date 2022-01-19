import { Page } from '../../domain/page';
import { AddSnippet, EditSnippet, SnippetItem } from '../../models/Snippet';
import AxiosHttp from '../http';
import { PageData } from '../../models/Page';

export default class CodeSnippetRepository {
    List(page: Page): Promise<PageData<SnippetItem>> {
        return AxiosHttp.Instance.get('/CodeSnippet/List', page);
    }

    Add(snippet: AddSnippet) {
        return AxiosHttp.Instance.post('/CodeSnippet/Add', snippet);
    }

    async Remove(id: string) {
        const data = {
            id: id,
        };
        return AxiosHttp.Instance.post('/CodeSnippet/Delete', data);
    }

    Get(id: string): Promise<EditSnippet> {
        const param = {
            id: id,
        };
        return AxiosHttp.Instance.get('/CodeSnippet/Detail', param);
    }

    async Edit(snippet: EditSnippet) {
        return AxiosHttp.Instance.post('/CodeSnippet/Edit', snippet);
    }
}

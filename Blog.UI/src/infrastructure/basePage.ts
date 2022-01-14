import { Component, Vue } from 'vue-property-decorator';
import {
    ConfirmDialogOperator,
    LoadingOperator,
    MessageOperator,
    SimpleConfirmDialogOperator,
    SimpleLoadingOperator,
    SimpleMessageOperator,
} from '@dydhyh/ui-tools';
import SimpleNavigation, { Navigation } from './navigator';

@Component
export default class BasePage extends Vue {
    protected message: MessageOperator = SimpleMessageOperator.Instance;
    protected loader: LoadingOperator = SimpleLoadingOperator.Instance;
    protected confirm: ConfirmDialogOperator =
        SimpleConfirmDialogOperator.Instance;
    protected navigator: Navigation = SimpleNavigation.Instance;
}

import {Vue, Component} from 'vue-property-decorator'
import { filter } from 'vue/types/umd'
@Component
export default class commonMixin extends Vue{
    filters:{
        toCurrency: function (value){
            
        }
    }
}
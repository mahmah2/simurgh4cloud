import { PictureModel } from './picture-model';

export class ClientModel {
  public id: number;
  public clientName: string;
  public clientDescription: string; 
  public googleMapAddress  :string; 
  public avatar            :string; 
  public rowNo: number    ; 
  
  public pictures: PictureModel[];
}

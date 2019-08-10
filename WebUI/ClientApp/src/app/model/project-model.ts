import { PictureModel } from './picture-model';

export class ProjectModel {
  public id :number;
  public name :string;
  public description :string; 
  public created  :Date; 
  public clientId  :string; 
  public projectStage: number;
  public evaluationDate: Date; 
  public evaluationAmount: number; 
  public moneyRaised: number; 
  public acctualMoneySpent: number;
  public executionStarted: Date;
  public finished: Date;
  public lastUpdated: Date;

  public rowNo :number;
  
  public pictures: PictureModel[];
}

import { MeasurementType } from './measurement-type';

export class Measurement {
  measurementType: MeasurementType;
  value: number;

  public constructor(init?: Partial<Measurement>) {
    Object.assign(this, init);
  }
}

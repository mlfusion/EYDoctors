import { Pipe, PipeTransform } from '@angular/core';
import { PatientRating } from '../_models/models';
import { forEach } from '../../../node_modules/@angular/router/src/utils/collection';
import { retry } from '../../../node_modules/rxjs/operators';

@Pipe({
  name: 'ratingstatus'
})
export class RatingStatusPipe implements PipeTransform {

  transform(ratings: PatientRating[], value: any): any {

      if (ratings.length == 0)
          return null
          
      let ratingTotal = 0;
      let total5 = 0

    ratings.forEach((item, index) => {

          if (item.rating == 5) {
              total5++
          }
        ratingTotal++;
      });
    
      //console.log('ratingTotal ' + ratingTotal)

      let percent = total5 * 100 / ratingTotal;

      //console.log('percent ' + percent)

      
     return (percent) > 85 ? 'SuperStar' : ''
  }

}

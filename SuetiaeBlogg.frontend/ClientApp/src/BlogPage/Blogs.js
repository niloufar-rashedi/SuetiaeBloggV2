import React, { Component } from 'react';
import Moment from 'react-moment';
import ReactRoundedImage from 'react-rounded-image';

class Blogs extends Component {
	render() {
		return (
			<div class="container p-4">
				<h3>Celebrate "kanelbullens dag" with a fantastic recipe</h3>
				<div>
					<div style={{ display: "flex" }}>
						<ReactRoundedImage
							image={'https://images.pexels.com/photos/2787341/pexels-photo-2787341.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940'}
							imageWidth="40"
							imageHeight="40"
							roundedSize="0"
						/>
						<p>Published: <Moment format="MM/DD/YYYY">10/04/2020</Moment> by Clara</p>
					</div>
				</div>
				<div class="row">
					<div class="col">
						<img src=" https://tidochdatum.se/img/events/kanelbullensdag.jpg" class="rounded mx-auto d-block" alt="Responsive image"/>
					</div>
				</div>
				<div class="col">
					<h2>The Cinnamon Bun Day</h2>
					<p class="text-justify">A bun with its roots in the 1920s. The Roaring Twenties was when cinnamon buns started to be made in bakeries, at least in the form they are today. It was no coincidence that this sweet treat started to appear around then, when things that had been rationed during the First World War began to be sold in shops again. It was however after the Second World War that cinnamon buns became really popular in Swedish homes.</p>

					<p>Always the 4th October. Cinnamon Bun Day was started as a yearly celebration in 1999 by the Hembakningsrådet (the Home Baking Council), to mark the council’s 40th anniversary. Autumn was chosen for the actual day to be celebrated so that it didn’t clash with other important Swedish foods, like semlor (Lenten Buns), waffles, meatballs and surströmming (fermented herring).</p>

				</div>
				<div class="row">
					<div class="col">

						<img src="https://cdn3.cdnme.se/cdn/8-2/173971/images/2007/kanelbullar_1191416790_2236592.jpg" class="rounded mx-auto d-block" alt="Responsive image" />
					</div>
				</div>
				<div class="col">
					<h2>RECIPE – HERE’S HOW TO BAKE GENUINE SWEDISH BUNS</h2>
					<p class="text-justify">
						<h3>Step 1 – make the dough</h3>

						Ingredients in the dough:</p>

						<p>6 decilitres (dl) milk</p>
						<p>225g butter at room temperature</p>
						<p>50g fresh yeast</p>
						<p>2.25 dl granulated sugar</p>
						<p>2 tbspn of freshly ground green cardamom seeds</p>
						<p>2 tspn ground cardamom</p>
						<p>2 tspn salt</p>
						<p>15–17 dl strong white flour</p>
						<p>2 eggs</p>
						<p>Do as follows:</p>

						<p>Warm the milk to 37˚C with the cardamom.
						Add the yeast and the other ingredients
						Knead to a smooth, slightly wet dough
						Let the dough double in size, covered with a damp cloth</p>

						<h3>Step 2 – shape the buns</h3>

						<p>Ingredients in the filling:</p>

						<p>300g butter at room temperature</p>
						<p>1 tbspn ground cinnamon</p >
						<p>1.5 dl caster sugar</p >
						<p>1 tbspn vanilla sugar</p >
						<p>1 tbspn ground cardamom</p >
						<p>Do as follows:</p >

						<p>Mix together the filling ingredients
						Roll out the dough onto a lightly floured board
						Spread the filling on the dough
						Form into your choice of bun shape (eg spirals or knots)
						Let the buns rise about 45 minutes under a damp cloth</p>

						<h3>Step 3 – baking</h3>

						<p>Ingredients for the glaze:</p>

						<p>2 eggs</p>
						<p>1 tbspn milk</p>
						<p>Do as follow:</p>

						<p>Preheat the oven to 210˚C
						Mix the egg and the milk for the glaze
						Brush the buns with the glaze
						Bake for around 5 minutes at 210˚C then sink the temperature to 200˚C and bake for a further 3 minutes or until the buns are golden brown.</p>
 
						<h3>Step 4 – decoration</h3>

						<p>Ingredients for the decoration:</p>

						<p>1 dl water</p>
						<p>2 tbspn syrup</p>
						<p>1 tbspn honey</p >
						<p>2 tbspn brown butter</p >
						<p>1 dl granulated sugar</p >
						<p>2 tspn ground cardamom</p >
						<p>Do as follows:</p >

						<p>Mix the water, syrup, honey and brown butter
						Brush the mixture on the warm freshly baked buns
						Mix the sugar and ground cardamom
						Sprinkle the mixture over the buns
						Delicious served with a glass of milk or a cup of freshly brewed coffee!</p >
						
				</div>

				

			</div>
		);
	}
}
			

export default Blogs;
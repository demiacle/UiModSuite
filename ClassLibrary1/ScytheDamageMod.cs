﻿using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Tools;

namespace Demiacle_SVM {
    public class ScytheDamageMod {

        public ScytheDamageMod() {
        }

        /// <summary>
        /// Makes all weapons only deal 1 dmg... mwahahahahaha
        /// Also replaces the Scythe with a SuperScythe.
        /// </summary>
        internal void onInvChange( object sender, EventArgsInventoryChanged e ) {
            foreach( StardewModdingAPI.Inheritance.ItemStackChange item in e.Removed ) {
                ModEntry.Log( "onInvChange " + item.Item.Name );
            }

            // makes all weapons weak af!
            for( int i = 0; i < e.Inventory.Count; i++ ) {
                if( e.Inventory[i] is MeleeWeapon && e.Inventory[i].Name != "Scythe" ) {
                    ModEntry.Log( e.Inventory[ i ].Name );
                    ( ( MeleeWeapon ) e.Inventory[ i ] ).minDamage = 1;
                    ( ( MeleeWeapon ) e.Inventory[ i ] ).maxDamage = 1;
                } else if( e.Inventory[ i ] is MeleeWeapon && e.Inventory[ i ].Name == "Scythe" ) {
                    e.Inventory[ i ] = null;
                    e.Inventory[ i ] = (Tool)(new Scythe());
                }
            }
        }

        public class Scythe : MeleeWeapon{
            public Scythe() : base( 47 ) {
                minDamage = 100;
                maxDamage = 200;
                //name = "SuperScythe"; this fails because crucial game code has checks against the name Scythe
                description = "Not your ordinary everyday scythe.";
            }
            public override void leftClick( Farmer who ) {
                base.leftClick( who );
                if( !who.UsingTool ) {
                    //who.stamina -= 10;
                }
            }
        }
    }
}
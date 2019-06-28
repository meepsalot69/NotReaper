using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Models {

	//KEEP IN MIND, almost all the song references are to the moggsong, not the mogg.
	// moggSusatinSongRight references the name of the mogg, the actual file is stored on the AudicaFile object.
	public class SongDesc {
		public string songID;

		public string moggSong;
		public string moggMainSong;
		public string cachedOggMainSong {
			get {
				return $"{this.songID}.ogg";
			}
		}

		public string title;
		public string artist;

		public string midiFile;

		public string fusionSpatialized;

		public string sustainSongRight;
		public string moggSustainSongRight;
		public string cachedOggSustainSongRight {
			get {
				return $"{this.songID}_sustain_r.ogg";
			}
		}

		public string sustainSongLeft;
		public string moggSustainSongLeft;
		public string cachedOggSustainSongLeft {
			get {
				return $"{this.songID}_sustain_l.ogg";
			}
		}

		public string fxSong;
		public string moggFxSong;

		public double tempo;
		public string songEndEvent;
		public double prerollSeconds;
		public bool useMidiForCues = false;
		public bool hidden = false;
		public string mapper;
	}

	public class CuesList {
		public List<Cue> expert = null;
		public List<Cue> advanced = null;
		public List<Cue> standard = null;
		public List<Cue> easy = null;

	}

	public class AudicaFile {
		public SongDesc desc;
		public AudioClip song;
		public CuesList cues = new CuesList();
		public AudioClip song_extras;
		public AudioClip song_sustain_l;
		public AudioClip song_sustain_r;
		public string filepath;

	}

	public enum TargetHandType { Either = 0, Right = 1, Left = 2, None = 3 }
	public enum TargetBehavior { Standard = 0, Vertical = 1, Horizontal = 2, Hold = 3, ChainStart = 4, Chain = 5, Melee = 6, HoldEnd = 7 }
	public enum TargetVelocity { Standard = 20, Vertical = 20, Horizontal = 20, Hold = 20, Snare = 127, Percussion = 60, ChainStart = 1, Chain = 2, Melee = 3 }

	public class Cue {
		public int tick;
		public int tickLength;
		public int pitch;
		public TargetVelocity velocity = TargetVelocity.Standard;
		public GridOffset gridOffset = new GridOffset { x = 0, y = 0 };
		public TargetHandType handType = TargetHandType.Right;
		public TargetBehavior behavior = TargetBehavior.Standard;

		public struct GridOffset {
			public double x;
			public double y;
		}
	}

}
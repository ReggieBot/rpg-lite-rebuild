using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// represents a single node in a branching dialog tree
    /// each node has a line of text and up to 4 player response options
    /// each leading to another DialogOption, forming a conversation tree
    /// </summary>
    public class DialogOption
    {
        // the text displayed to the player (what the NPC/enemy says)
        public string Lines { get; set; }
        // up to 4 player response options
        // key = button label shown to the player (e.g. "Ask about quest")
        // value = the next DialogOption triggered by that choice
        // if value is null, choosing this option ends the dialog or starts combat
        public Dictionary<string, DialogOption> Responses { get; set; }
        /// <summary>
        /// creates a new dialog node with the specified text and an empty response dictionary
        /// </summary>
        public DialogOption(string lines)
        {
            Lines = lines;
            Responses = new Dictionary<string, DialogOption>();
        }
        /// <summary>
        /// adds a response option to this dialog node
        /// limited to 4 responses maximum to match the UI button layout
        /// </summary>
        public void AddResponse(string buttonLabel, DialogOption nextDialog)
        {
            if (Responses.Count < 4)
                Responses[buttonLabel] = nextDialog;
        }
        // true if this node has no further responses (conversation ends here)
        public bool IsEndOfDialog => Responses == null || Responses.Count == 0;
    }
}
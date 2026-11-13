
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalityServicesApplication22
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly MainMenuForm mainMenu;
        private bool returningToMenu;

        // Binary Search Tree for finding requests by ID
        private BSTNode root;

        // Priority queue implemented with SortedSet
        private SortedSet<ServiceRequest> priorityHeap;

        // Graph representing relationships between requests
        private Dictionary<string, List<string>> requestGraph;

        // Fast lookup of requests by ID
        private Dictionary<string, ServiceRequest> requestLookup;

        public ServiceRequestStatusForm() : this(null)
        {
        }

        public ServiceRequestStatusForm(MainMenuForm menu)
        {
            mainMenu = menu;

            priorityHeap = new SortedSet<ServiceRequest>(
                Comparer<ServiceRequest>.Create((a, b) =>
                {
                    int result = a.Priority.CompareTo(b.Priority);

                    if (result != 0)
                        return result;

                    result = a.SubmittedDate.CompareTo(b.SubmittedDate);

                    if (result != 0)
                        return result;

                    return string.Compare(
                        a.Id,
                        b.Id,
                        StringComparison.Ordinal
                    );
                })
            );

            requestGraph = new Dictionary<string, List<string>>();
            requestLookup = new Dictionary<string, ServiceRequest>();

            InitializeComponent();

            LoadExistingRequests();
            RebuildStructures();
            RefreshList();
        }

        // =========================================
        // BINARY SEARCH TREE
        // =========================================

        private class BSTNode
        {
            public ServiceRequest Request;
            public BSTNode Left;
            public BSTNode Right;

            public BSTNode(ServiceRequest request)
            {
                Request = request;
            }
        }

        private void InsertIntoBST(ServiceRequest request)
        {
            root = InsertNode(root, request);
        }

        private BSTNode InsertNode(
            BSTNode node,
            ServiceRequest request)
        {
            if (node == null)
                return new BSTNode(request);

            int comparison = string.Compare(
                request.Id,
                node.Request.Id,
                StringComparison.OrdinalIgnoreCase
            );

            if (comparison < 0)
            {
                node.Left = InsertNode(node.Left, request);
            }
            else if (comparison > 0)
            {
                node.Right = InsertNode(node.Right, request);
            }
            else
            {
                // Replace an existing request with the same ID.
                node.Request = request;
            }

            return node;
        }

        private ServiceRequest SearchBST(string id)
        {
            BSTNode current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    id,
                    current.Request.Id,
                    StringComparison.OrdinalIgnoreCase
                );

                if (comparison == 0)
                    return current.Request;

                current = comparison < 0
                    ? current.Left
                    : current.Right;
            }

            return null;
        }

        // =========================================
        // LOAD AND REBUILD DATA STRUCTURES
        // =========================================

        private void LoadExistingRequests()
        {
            // This method uses your existing RequestManager.
            // If your application stores requests differently,
            // change this line to your actual data source.
            if (RequestManager.AllRequests == null)
                return;

            foreach (ServiceRequest request in RequestManager.AllRequests)
            {
                if (request == null || string.IsNullOrWhiteSpace(request.Id))
                    continue;

                InsertIntoBST(request);
            }
        }

        private void RebuildStructures()
        {
            priorityHeap.Clear();
            requestGraph.Clear();
            requestLookup.Clear();

            List<ServiceRequest> requests = GetAllRequestsFromBST();

            foreach (ServiceRequest request in requests)
            {
                if (request == null ||
                    string.IsNullOrWhiteSpace(request.Id))
                {
                    continue;
                }

                requestLookup[request.Id] = request;
                priorityHeap.Add(request);

                if (!requestGraph.ContainsKey(request.Id))
                    requestGraph[request.Id] = new List<string>();
            }

            // Connect requests in submission order to create a graph
            // for demonstrating BFS and MST algorithms.
            List<ServiceRequest> orderedRequests = requests
                .Where(r => r != null &&
                            !string.IsNullOrWhiteSpace(r.Id))
                .OrderBy(r => r.SubmittedDate)
                .ToList();

            for (int i = 0; i < orderedRequests.Count - 1; i++)
            {
                string firstId = orderedRequests[i].Id;
                string secondId = orderedRequests[i + 1].Id;

                AddGraphEdge(firstId, secondId);
            }
        }

        private List<ServiceRequest> GetAllRequestsFromBST()
        {
            List<ServiceRequest> requests = new List<ServiceRequest>();

            TraverseInOrder(root, requests);

            return requests;
        }

        private void TraverseInOrder(
            BSTNode node,
            List<ServiceRequest> requests)
        {
            if (node == null)
                return;

            TraverseInOrder(node.Left, requests);
            requests.Add(node.Request);
            TraverseInOrder(node.Right, requests);
        }

        private void AddGraphEdge(string firstId, string secondId)
        {
            if (firstId == secondId)
                return;

            if (!requestGraph.ContainsKey(firstId))
                requestGraph[firstId] = new List<string>();

            if (!requestGraph.ContainsKey(secondId))
                requestGraph[secondId] = new List<string>();

            if (!requestGraph[firstId].Contains(secondId))
                requestGraph[firstId].Add(secondId);

            if (!requestGraph[secondId].Contains(firstId))
                requestGraph[secondId].Add(firstId);
        }

        // =========================================
        // DISPLAY REQUESTS
        // =========================================

        private void RefreshList()
        {
            lstRequests.Items.Clear();

            List<ServiceRequest> requests = GetAllRequestsFromBST();

            if (requests.Count == 0)
            {
                lstRequests.Items.Add("No service requests found.");
                return;
            }

            foreach (ServiceRequest request in requests)
            {
                lstRequests.Items.Add(
                    "ID: " + request.Id +
                    " | Priority: " + request.Priority +
                    " | Submitted: " + request.SubmittedDate
                );
            }
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            RefreshList();
            lstGraphOutput.Items.Clear();
            lstGraphOutput.Items.Add(
                "All requests displayed in ID order."
            );
        }

        // =========================================
        // SEARCH USING BINARY SEARCH TREE
        // =========================================

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearchId.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show(
                    "Please enter a service request ID.",
                    "Search Request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSearchId.Focus();
                return;
            }

            ServiceRequest request = SearchBST(id);

            lstRequests.Items.Clear();
            lstGraphOutput.Items.Clear();

            if (request == null)
            {
                lstRequests.Items.Add(
                    "No request found with ID: " + id
                );

                lstGraphOutput.Items.Add(
                    "BST search completed. No matching request."
                );

                return;
            }

            lstRequests.Items.Add("Service Request Found");
            lstRequests.Items.Add("-----------------------------");
            lstRequests.Items.Add("ID: " + request.Id);
            lstRequests.Items.Add("Priority: " + request.Priority);
            lstRequests.Items.Add(
                "Submitted: " + request.SubmittedDate
            );

            lstGraphOutput.Items.Add(
                "BST search successful for ID: " + request.Id
            );
        }

        // =========================================
        // BREADTH-FIRST SEARCH (BFS)
        // =========================================

        private void BtnTraverse_Click(object sender, EventArgs e)
        {
            lstGraphOutput.Items.Clear();

            if (requestGraph.Count == 0)
            {
                lstGraphOutput.Items.Add(
                    "No requests available for graph traversal."
                );
                return;
            }

            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();

            int componentNumber = 0;

            lstGraphOutput.Items.Add(
                "Breadth-First Search (BFS) Traversal"
            );
            lstGraphOutput.Items.Add(
                "-----------------------------------"
            );

            foreach (string startId in requestGraph.Keys.OrderBy(id => id))
            {
                if (visited.Contains(startId))
                    continue;

                componentNumber++;
                queue.Enqueue(startId);
                visited.Add(startId);

                lstGraphOutput.Items.Add(
                    "Component " + componentNumber + ":"
                );

                while (queue.Count > 0)
                {
                    string currentId = queue.Dequeue();

                    lstGraphOutput.Items.Add(
                        "Visited request: " + currentId
                    );

                    foreach (string neighbour in requestGraph[currentId]
                        .OrderBy(id => id))
                    {
                        if (visited.Contains(neighbour))
                            continue;

                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        // =========================================
        // MINIMUM SPANNING TREE (KRUSKAL'S ALGORITHM)
        // =========================================

        private class GraphEdge
        {
            public string FirstId;
            public string SecondId;
            public int Weight;

            public GraphEdge(
                string firstId,
                string secondId,
                int weight)
            {
                FirstId = firstId;
                SecondId = secondId;
                Weight = weight;
            }
        }

        private void BtnMST_Click(object sender, EventArgs e)
        {
            lstGraphOutput.Items.Clear();

            List<string> vertices = requestGraph.Keys
                .OrderBy(id => id)
                .ToList();

            if (vertices.Count == 0)
            {
                lstGraphOutput.Items.Add(
                    "No requests available for MST calculation."
                );
                return;
            }

            List<GraphEdge> edges = new List<GraphEdge>();

            foreach (string firstId in requestGraph.Keys)
            {
                foreach (string secondId in requestGraph[firstId])
                {
                    // Add each undirected edge once.
                    if (string.Compare(
                        firstId,
                        secondId,
                        StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }

                    // Edge weight represents the absolute difference
                    // between the two request priorities.
                    int firstPriority =
                        requestLookup[firstId].Priority;

                    int secondPriority =
                        requestLookup[secondId].Priority;

                    int weight = Math.Abs(
                        firstPriority - secondPriority
                    );

                    edges.Add(
                        new GraphEdge(firstId, secondId, weight)
                    );
                }
            }

            edges = edges
                .OrderBy(edge => edge.Weight)
                .ThenBy(edge => edge.FirstId)
                .ThenBy(edge => edge.SecondId)
                .ToList();

            Dictionary<string, string> parent =
                new Dictionary<string, string>();

            foreach (string vertex in vertices)
                parent[vertex] = vertex;

            List<GraphEdge> mstEdges = new List<GraphEdge>();

            foreach (GraphEdge edge in edges)
            {
                string firstRoot = FindRoot(parent, edge.FirstId);
                string secondRoot = FindRoot(parent, edge.SecondId);

                if (firstRoot == secondRoot)
                    continue;

                parent[firstRoot] = secondRoot;
                mstEdges.Add(edge);

                if (mstEdges.Count == vertices.Count - 1)
                    break;
            }

            lstGraphOutput.Items.Add(
                "Minimum Spanning Tree (Kruskal's Algorithm)"
            );
            lstGraphOutput.Items.Add(
                "--------------------------------------------"
            );

            int totalWeight = 0;

            foreach (GraphEdge edge in mstEdges)
            {
                lstGraphOutput.Items.Add(
                    edge.FirstId + " <-> " +
                    edge.SecondId + " | Weight: " + edge.Weight
                );

                totalWeight += edge.Weight;
            }

            lstGraphOutput.Items.Add("--------------------------------------------");
            lstGraphOutput.Items.Add(
                "Total MST weight: " + totalWeight
            );

            if (mstEdges.Count < vertices.Count - 1)
            {
                lstGraphOutput.Items.Add(
                    "Note: The graph is disconnected. " +
                    "A single spanning tree cannot connect all requests."
                );
            }
        }

        private string FindRoot(
            Dictionary<string, string> parent,
            string vertex)
        {
            if (parent[vertex] != vertex)
                parent[vertex] = FindRoot(parent, parent[vertex]);

            return parent[vertex];
        }

        // =========================================
        // RETURN TO MAIN MENU
        // =========================================

        private void BtnBack_Click(object sender, EventArgs e)
        {
            returningToMenu = true;

            if (mainMenu != null && !mainMenu.IsDisposed)
            {
                mainMenu.Show();
                mainMenu.Activate();
            }
            else
            {
                MainMenuForm menu = new MainMenuForm();
                menu.Show();
            }

            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.Cancel ||
                returningToMenu ||
                e.CloseReason != CloseReason.UserClosing)
            {
                return;
            }

            if (mainMenu != null && !mainMenu.IsDisposed)
            {
                mainMenu.Show();
                mainMenu.Activate();
            }
        }
    }
}

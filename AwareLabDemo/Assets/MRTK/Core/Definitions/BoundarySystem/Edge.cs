// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Boundary
{
    /// <summary>
    /// The Edge structure defines the points of a line segment that are used to
    /// construct a polygonal boundary.
    /// </summary>
    public struct Edge
    {
        /// <summary>
        /// The first point of the edge line segment.
        /// </summary>
        public readonly Vector2 PointA;

        /// <summary>
        /// The second point of the edge line segment.
        /// </summary>
        public readonly Vector2 PointB;

        /// <summary>
        /// Initializes the Edge structure.
        /// </summary>
        /// <param name="pointA">The first point of the line segment.</param>
        /// <param name="pointB">The second point of the line segment.</param>
        public Edge(Vector2 pointA, Vector2 pointB)
        {
            PointA = pointA;
            PointB = pointB;
        }

        /// <summary>
        /// Initializes the Edge structure.
        /// </summary>
        /// <param name="pointA">The first point of the line segment.</param>
        /// <param name="pointB">The second point of the line segment.</param>
        public Edge(Vector3 pointA, Vector3 pointB) :
            // Use the X and Z parameters as our edges are height agnostic.
            this(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z))
        { }
    }
}

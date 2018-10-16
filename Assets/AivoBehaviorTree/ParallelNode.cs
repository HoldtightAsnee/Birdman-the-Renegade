﻿using System;
using System.Linq;

namespace AivoTree
{
    public class ParellelNode<T> : TreeNode<T>
    {
        private readonly TreeNode<T>[] _nodes;

        public ParellelNode(params TreeNode<T>[] nodes)
        {
            _nodes = nodes;
        }

		public AivoTreeStatus Tick(float timeTick, T context)
		{
			var nodesToSearch = _nodes;
			return nodesToSearch.Aggregate(AivoTreeStatus.Running, (acc, curr) =>
			{
				if (acc != AivoTreeStatus.Running)
				{
					var result = curr.Tick(timeTick, context);
					return result;
				}
				return acc;
			});
		}
	}
}